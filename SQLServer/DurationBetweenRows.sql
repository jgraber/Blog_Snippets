BEGIN TRAN

---------------   #TaskDuration   ---------------
SELECT * INTO #TaskDuration
FROM (
SELECT 1 AS [Id], 100 AS [TaskId], N'Start' AS [Action], '2022-08-01 08:00:00.000' AS [Timestamp] UNION ALL
SELECT 2 AS [Id], 101 AS [TaskId], N'Start' AS [Action], '2022-08-02 07:30:00.000' AS [Timestamp] UNION ALL
SELECT 3 AS [Id], 100 AS [TaskId], N'Stop' AS [Action], '2022-08-03 17:00:00.000' AS [Timestamp] UNION ALL
SELECT 4 AS [Id], 102 AS [TaskId], N'Start' AS [Action], '2022-08-04 08:00:00.000' AS [Timestamp] UNION ALL
SELECT 5 AS [Id], 102 AS [TaskId], N'Stop' AS [Action], '2022-08-04 17:00:00.000' AS [Timestamp] UNION ALL
SELECT 6 AS [Id], 101 AS [TaskId], N'Stop' AS [Action], '2022-08-05 18:00:00.000' AS [Timestamp] )t;

SELECT [Id], [TaskId], [Action], [Timestamp]
FROM #TaskDuration


SELECT
	[TaskId], 
	CONVERT(DATE, taskStart.[Timestamp]) AS 'Start',
	CONVERT(DATE, taskEnd.[Timestamp]) AS 'End',
	DATEDIFF(day, taskStart.[Timestamp], taskEnd.[Timestamp]) + 1 as 'Duration'
FROM #TaskDuration taskStart
OUTER APPLY (
	SELECT TOP(1)
		taskEnd.[Timestamp]
	FROM #TaskDuration taskEnd
	WHERE 
		taskEnd.[Timestamp] > taskStart.[Timestamp]
		AND taskEnd.[Action] = 'Stop'
		AND taskEnd.TaskId = taskStart.TaskId
	ORDER BY [Timestamp]
	) taskEnd
WHERE
	taskStart.Action = 'Start'


DROP TABLE #TaskDuration
GO



ROLLBACK